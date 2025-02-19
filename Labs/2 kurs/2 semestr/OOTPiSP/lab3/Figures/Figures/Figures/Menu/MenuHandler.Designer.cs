namespace Figures.Menu
{
    partial class MenuHandler
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.textColorDialog = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.inputText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputTextSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fontStyle = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.figureType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.inputDx = new System.Windows.Forms.TextBox();
            this.inputDy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.inputWidth = new System.Windows.Forms.TextBox();
            this.inputHeight = new System.Windows.Forms.TextBox();
            this.inputBorderWidth = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.inputX = new System.Windows.Forms.TextBox();
            this.inputY = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bColorBox = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.fColorBox = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.fontColorBox = new System.Windows.Forms.PictureBox();
            this.Edit = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.colorDialog3 = new System.Windows.Forms.ColorDialog();
            this.colorDialog4 = new System.Windows.Forms.ColorDialog();
            this.colorDialog5 = new System.Windows.Forms.ColorDialog();
            this.colorDialog6 = new System.Windows.Forms.ColorDialog();
            this.bTextBoxR = new System.Windows.Forms.TextBox();
            this.bTextBoxG = new System.Windows.Forms.TextBox();
            this.bTextBoxB = new System.Windows.Forms.TextBox();
            this.fTextBoxR = new System.Windows.Forms.TextBox();
            this.fTextBoxG = new System.Windows.Forms.TextBox();
            this.fTextBoxB = new System.Windows.Forms.TextBox();
            this.fontTextBoxR = new System.Windows.Forms.TextBox();
            this.fontTextBoxG = new System.Windows.Forms.TextBox();
            this.fontTextBoxB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontColorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(25, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(162, 39);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(250, 22);
            this.inputText.TabIndex = 2;
            this.inputText.TextChanged += new System.EventHandler(this.inputText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(25, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Text size";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // inputTextSize
            // 
            this.inputTextSize.Location = new System.Drawing.Point(162, 79);
            this.inputTextSize.Name = "inputTextSize";
            this.inputTextSize.Size = new System.Drawing.Size(250, 22);
            this.inputTextSize.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(25, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Font style";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // fontStyle
            // 
            this.fontStyle.FormattingEnabled = true;
            this.fontStyle.Items.AddRange(new object[] {
            "Times New Roman",
            "Calibri",
            "Arial",
            "Tai Le"});
            this.fontStyle.Location = new System.Drawing.Point(162, 126);
            this.fontStyle.Name = "fontStyle";
            this.fontStyle.Size = new System.Drawing.Size(250, 24);
            this.fontStyle.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(25, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Type of figure";
            // 
            // figureType
            // 
            this.figureType.FormattingEnabled = true;
            this.figureType.Items.AddRange(new object[] {
            "rectangle",
            "circle",
            "triangle",
            "ellipse",
            "square"});
            this.figureType.Location = new System.Drawing.Point(162, 170);
            this.figureType.Name = "figureType";
            this.figureType.Size = new System.Drawing.Size(250, 24);
            this.figureType.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(25, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "dx";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(25, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "dy";
            // 
            // inputDx
            // 
            this.inputDx.Location = new System.Drawing.Point(162, 330);
            this.inputDx.Name = "inputDx";
            this.inputDx.Size = new System.Drawing.Size(250, 22);
            this.inputDx.TabIndex = 11;
            // 
            // inputDy
            // 
            this.inputDy.Location = new System.Drawing.Point(162, 362);
            this.inputDy.Name = "inputDy";
            this.inputDy.Size = new System.Drawing.Size(250, 22);
            this.inputDy.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(25, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Width";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(25, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Height";
            // 
            // inputWidth
            // 
            this.inputWidth.Location = new System.Drawing.Point(162, 208);
            this.inputWidth.Name = "inputWidth";
            this.inputWidth.Size = new System.Drawing.Size(250, 22);
            this.inputWidth.TabIndex = 15;
            // 
            // inputHeight
            // 
            this.inputHeight.Location = new System.Drawing.Point(162, 254);
            this.inputHeight.Name = "inputHeight";
            this.inputHeight.Size = new System.Drawing.Size(250, 22);
            this.inputHeight.TabIndex = 16;
            this.inputHeight.TextChanged += new System.EventHandler(this.inputHeight_TextChanged);
            // 
            // inputBorderWidth
            // 
            this.inputBorderWidth.Location = new System.Drawing.Point(162, 291);
            this.inputBorderWidth.Name = "inputBorderWidth";
            this.inputBorderWidth.Size = new System.Drawing.Size(250, 22);
            this.inputBorderWidth.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(25, 291);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Border width";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(25, 397);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "Coordinate X";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(25, 433);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "Coordinate Y";
            // 
            // inputX
            // 
            this.inputX.Location = new System.Drawing.Point(162, 397);
            this.inputX.Name = "inputX";
            this.inputX.Size = new System.Drawing.Size(250, 22);
            this.inputX.TabIndex = 22;
            // 
            // inputY
            // 
            this.inputY.Location = new System.Drawing.Point(162, 431);
            this.inputY.Name = "inputY";
            this.inputY.Size = new System.Drawing.Size(250, 22);
            this.inputY.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 498);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 27);
            this.button1.TabIndex = 24;
            this.button1.Text = "Border Color";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bColorBox
            // 
            this.bColorBox.Location = new System.Drawing.Point(12, 531);
            this.bColorBox.Name = "bColorBox";
            this.bColorBox.Size = new System.Drawing.Size(132, 27);
            this.bColorBox.TabIndex = 25;
            this.bColorBox.TabStop = false;
            this.bColorBox.WaitOnLoad = true;
            this.bColorBox.Click += new System.EventHandler(this.bColorBox_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(12, 564);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 27);
            this.button2.TabIndex = 26;
            this.button2.Text = "Fill Color";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fColorBox
            // 
            this.fColorBox.Location = new System.Drawing.Point(12, 597);
            this.fColorBox.Name = "fColorBox";
            this.fColorBox.Size = new System.Drawing.Size(132, 27);
            this.fColorBox.TabIndex = 27;
            this.fColorBox.TabStop = false;
            this.fColorBox.WaitOnLoad = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(12, 630);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 27);
            this.button3.TabIndex = 28;
            this.button3.Text = "Font Color";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // fontColorBox
            // 
            this.fontColorBox.Location = new System.Drawing.Point(12, 663);
            this.fontColorBox.Name = "fontColorBox";
            this.fontColorBox.Size = new System.Drawing.Size(132, 27);
            this.fontColorBox.TabIndex = 29;
            this.fontColorBox.TabStop = false;
            this.fontColorBox.WaitOnLoad = true;
            this.fontColorBox.Click += new System.EventHandler(this.fontColorBox_Click);
            // 
            // Edit
            // 
            this.Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Edit.Location = new System.Drawing.Point(146, 701);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(132, 27);
            this.Edit.TabIndex = 30;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // bTextBoxR
            // 
            this.bTextBoxR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bTextBoxR.Location = new System.Drawing.Point(162, 498);
            this.bTextBoxR.Name = "bTextBoxR";
            this.bTextBoxR.Size = new System.Drawing.Size(39, 27);
            this.bTextBoxR.TabIndex = 32;
            // 
            // bTextBoxG
            // 
            this.bTextBoxG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bTextBoxG.Location = new System.Drawing.Point(223, 498);
            this.bTextBoxG.Name = "bTextBoxG";
            this.bTextBoxG.Size = new System.Drawing.Size(39, 27);
            this.bTextBoxG.TabIndex = 33;
            // 
            // bTextBoxB
            // 
            this.bTextBoxB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bTextBoxB.Location = new System.Drawing.Point(283, 498);
            this.bTextBoxB.Name = "bTextBoxB";
            this.bTextBoxB.Size = new System.Drawing.Size(39, 27);
            this.bTextBoxB.TabIndex = 34;
            // 
            // fTextBoxR
            // 
            this.fTextBoxR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fTextBoxR.Location = new System.Drawing.Point(162, 564);
            this.fTextBoxR.Name = "fTextBoxR";
            this.fTextBoxR.Size = new System.Drawing.Size(39, 27);
            this.fTextBoxR.TabIndex = 35;
            // 
            // fTextBoxG
            // 
            this.fTextBoxG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fTextBoxG.Location = new System.Drawing.Point(223, 564);
            this.fTextBoxG.Name = "fTextBoxG";
            this.fTextBoxG.Size = new System.Drawing.Size(39, 27);
            this.fTextBoxG.TabIndex = 36;
            // 
            // fTextBoxB
            // 
            this.fTextBoxB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fTextBoxB.Location = new System.Drawing.Point(283, 564);
            this.fTextBoxB.Name = "fTextBoxB";
            this.fTextBoxB.Size = new System.Drawing.Size(39, 27);
            this.fTextBoxB.TabIndex = 37;
            // 
            // fontTextBoxR
            // 
            this.fontTextBoxR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fontTextBoxR.Location = new System.Drawing.Point(162, 630);
            this.fontTextBoxR.Name = "fontTextBoxR";
            this.fontTextBoxR.Size = new System.Drawing.Size(39, 27);
            this.fontTextBoxR.TabIndex = 38;
            // 
            // fontTextBoxG
            // 
            this.fontTextBoxG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fontTextBoxG.Location = new System.Drawing.Point(223, 630);
            this.fontTextBoxG.Name = "fontTextBoxG";
            this.fontTextBoxG.Size = new System.Drawing.Size(39, 27);
            this.fontTextBoxG.TabIndex = 39;
            // 
            // fontTextBoxB
            // 
            this.fontTextBoxB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fontTextBoxB.Location = new System.Drawing.Point(283, 630);
            this.fontTextBoxB.Name = "fontTextBoxB";
            this.fontTextBoxB.Size = new System.Drawing.Size(39, 27);
            this.fontTextBoxB.TabIndex = 40;
            // 
            // MenuHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(440, 740);
            this.Controls.Add(this.fontTextBoxB);
            this.Controls.Add(this.fontTextBoxG);
            this.Controls.Add(this.fontTextBoxR);
            this.Controls.Add(this.fTextBoxB);
            this.Controls.Add(this.fTextBoxG);
            this.Controls.Add(this.fTextBoxR);
            this.Controls.Add(this.bTextBoxB);
            this.Controls.Add(this.bTextBoxG);
            this.Controls.Add(this.bTextBoxR);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.fontColorBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.fColorBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bColorBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inputY);
            this.Controls.Add(this.inputX);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.inputBorderWidth);
            this.Controls.Add(this.inputHeight);
            this.Controls.Add(this.inputWidth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.inputDy);
            this.Controls.Add(this.inputDx);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.figureType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fontStyle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputTextSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuHandler";
            this.Text = "EditMenu";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.MenuHandler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontColorBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ColorDialog textColorDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputTextSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox fontStyle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox figureType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox inputDx;
        private System.Windows.Forms.TextBox inputDy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox inputWidth;
        private System.Windows.Forms.TextBox inputHeight;
        private System.Windows.Forms.TextBox inputBorderWidth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox inputX;
        private System.Windows.Forms.TextBox inputY;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ColorDialog colorDialog3;
        private System.Windows.Forms.ColorDialog colorDialog4;
        private System.Windows.Forms.ColorDialog colorDialog5;
        private System.Windows.Forms.ColorDialog colorDialog6;
        public System.Windows.Forms.PictureBox bColorBox;
        public System.Windows.Forms.PictureBox fColorBox;
        public System.Windows.Forms.PictureBox fontColorBox;
        private System.Windows.Forms.TextBox bTextBoxR;
        private System.Windows.Forms.TextBox bTextBoxG;
        private System.Windows.Forms.TextBox bTextBoxB;
        private System.Windows.Forms.TextBox fTextBoxR;
        private System.Windows.Forms.TextBox fTextBoxG;
        private System.Windows.Forms.TextBox fTextBoxB;
        private System.Windows.Forms.TextBox fontTextBoxR;
        private System.Windows.Forms.TextBox fontTextBoxG;
        private System.Windows.Forms.TextBox fontTextBoxB;
    }
}



