namespace TI_4
{
    partial class MainForm
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
            this.LabelP = new System.Windows.Forms.Label();
            this.TextBoxP = new System.Windows.Forms.TextBox();
            this.TextBoxQ = new System.Windows.Forms.TextBox();
            this.LabelQ = new System.Windows.Forms.Label();
            this.TextBoxR = new System.Windows.Forms.TextBox();
            this.LabelR = new System.Windows.Forms.Label();
            this.ButtonR = new System.Windows.Forms.Button();
            this.TextBoxD = new System.Windows.Forms.TextBox();
            this.EulerLabel = new System.Windows.Forms.Label();
            this.TextBoxEuler = new System.Windows.Forms.TextBox();
            this.RadioButtonCreate = new System.Windows.Forms.RadioButton();
            this.RadioButtonCheck = new System.Windows.Forms.RadioButton();
            this.TextBoxE = new System.Windows.Forms.TextBox();
            this.PlainText = new System.Windows.Forms.TextBox();
            this.PlainLabel = new System.Windows.Forms.Label();
            this.ResultButton = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.TextBoxHash = new System.Windows.Forms.TextBox();
            this.TextBoxEDS = new System.Windows.Forms.TextBox();
            this.HashLabel = new System.Windows.Forms.Label();
            this.EDSLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ClearLines = new System.Windows.Forms.Button();
            this.LoadFromFile = new System.Windows.Forms.Button();
            this.SaveToFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelP
            // 
            this.LabelP.Location = new System.Drawing.Point(0, 57);
            this.LabelP.Name = "LabelP";
            this.LabelP.Size = new System.Drawing.Size(100, 23);
            this.LabelP.TabIndex = 1;
            this.LabelP.Text = "P:";
            // 
            // TextBoxP
            // 
            this.TextBoxP.Location = new System.Drawing.Point(39, 50);
            this.TextBoxP.Name = "TextBoxP";
            this.TextBoxP.Size = new System.Drawing.Size(222, 39);
            this.TextBoxP.TabIndex = 2;
            this.TextBoxP.TextChanged += new System.EventHandler(this.ClearStrip_Click);
            // 
            // TextBoxQ
            // 
            this.TextBoxQ.Location = new System.Drawing.Point(39, 102);
            this.TextBoxQ.Name = "TextBoxQ";
            this.TextBoxQ.Size = new System.Drawing.Size(222, 39);
            this.TextBoxQ.TabIndex = 4;
            this.TextBoxQ.TextChanged += new System.EventHandler(this.ClearStrip_Click);
            // 
            // LabelQ
            // 
            this.LabelQ.Location = new System.Drawing.Point(0, 108);
            this.LabelQ.Name = "LabelQ";
            this.LabelQ.Size = new System.Drawing.Size(100, 23);
            this.LabelQ.TabIndex = 3;
            this.LabelQ.Text = "Q:";
            // 
            // TextBoxR
            // 
            this.TextBoxR.Location = new System.Drawing.Point(349, 50);
            this.TextBoxR.Multiline = true;
            this.TextBoxR.Name = "TextBoxR";
            this.TextBoxR.ReadOnly = true;
            this.TextBoxR.Size = new System.Drawing.Size(275, 39);
            this.TextBoxR.TabIndex = 5;
            // 
            // LabelR
            // 
            this.LabelR.Location = new System.Drawing.Point(306, 57);
            this.LabelR.Name = "LabelR";
            this.LabelR.Size = new System.Drawing.Size(37, 23);
            this.LabelR.TabIndex = 6;
            this.LabelR.Text = "R:";
            // 
            // ButtonR
            // 
            this.ButtonR.Location = new System.Drawing.Point(19, 224);
            this.ButtonR.Name = "ButtonR";
            this.ButtonR.Size = new System.Drawing.Size(222, 30);
            this.ButtonR.TabIndex = 7;
            this.ButtonR.Text = "Solve";
            this.ButtonR.UseVisualStyleBackColor = true;
            this.ButtonR.Click += new System.EventHandler(this.ButtonR_Click);
            // 
            // TextBoxD
            // 
            this.TextBoxD.Location = new System.Drawing.Point(39, 159);
            this.TextBoxD.Name = "TextBoxD";
            this.TextBoxD.Size = new System.Drawing.Size(222, 39);
            this.TextBoxD.TabIndex = 9;
            this.TextBoxD.TextChanged += new System.EventHandler(this.ClearStrip_Click);
            // 
            // EulerLabel
            // 
            this.EulerLabel.Location = new System.Drawing.Point(306, 105);
            this.EulerLabel.Name = "EulerLabel";
            this.EulerLabel.Size = new System.Drawing.Size(56, 23);
            this.EulerLabel.TabIndex = 10;
            this.EulerLabel.Text = "φ(R):";
            // 
            // TextBoxEuler
            // 
            this.TextBoxEuler.Location = new System.Drawing.Point(349, 102);
            this.TextBoxEuler.Multiline = true;
            this.TextBoxEuler.Name = "TextBoxEuler";
            this.TextBoxEuler.ReadOnly = true;
            this.TextBoxEuler.Size = new System.Drawing.Size(275, 39);
            this.TextBoxEuler.TabIndex = 11;
            // 
            // RadioButtonCreate
            // 
            this.RadioButtonCreate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RadioButtonCreate.Checked = true;
            this.RadioButtonCreate.Location = new System.Drawing.Point(6, 334);
            this.RadioButtonCreate.Name = "RadioButtonCreate";
            this.RadioButtonCreate.Size = new System.Drawing.Size(249, 24);
            this.RadioButtonCreate.TabIndex = 12;
            this.RadioButtonCreate.TabStop = true;
            this.RadioButtonCreate.Text = "CreatingSign";
            this.RadioButtonCreate.UseVisualStyleBackColor = true;
            this.RadioButtonCreate.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // RadioButtonCheck
            // 
            this.RadioButtonCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RadioButtonCheck.Location = new System.Drawing.Point(4, 381);
            this.RadioButtonCheck.Name = "RadioButtonCheck";
            this.RadioButtonCheck.Size = new System.Drawing.Size(249, 24);
            this.RadioButtonCheck.TabIndex = 13;
            this.RadioButtonCheck.Text = "CheckingSign";
            this.RadioButtonCheck.UseVisualStyleBackColor = true;
            this.RadioButtonCheck.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // TextBoxE
            // 
            this.TextBoxE.Location = new System.Drawing.Point(349, 159);
            this.TextBoxE.Multiline = true;
            this.TextBoxE.Name = "TextBoxE";
            this.TextBoxE.ReadOnly = true;
            this.TextBoxE.Size = new System.Drawing.Size(275, 39);
            this.TextBoxE.TabIndex = 14;
            // 
            // PlainText
            // 
            this.PlainText.Location = new System.Drawing.Point(39, 516);
            this.PlainText.Multiline = true;
            this.PlainText.Name = "PlainText";
            this.PlainText.ReadOnly = true;
            this.PlainText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PlainText.Size = new System.Drawing.Size(608, 105);
            this.PlainText.TabIndex = 16;
            // 
            // PlainLabel
            // 
            this.PlainLabel.Location = new System.Drawing.Point(12, 470);
            this.PlainLabel.Name = "PlainLabel";
            this.PlainLabel.Size = new System.Drawing.Size(584, 23);
            this.PlainLabel.TabIndex = 17;
            this.PlainLabel.Text = "Original message:";
            // 
            // ResultButton
            // 
            this.ResultButton.BackColor = System.Drawing.SystemColors.Control;
            this.ResultButton.Enabled = false;
            this.ResultButton.Location = new System.Drawing.Point(171, 666);
            this.ResultButton.Name = "ResultButton";
            this.ResultButton.Size = new System.Drawing.Size(275, 57);
            this.ResultButton.TabIndex = 20;
            this.ResultButton.Text = "Calculate";
            this.ResultButton.UseVisualStyleBackColor = false;
            this.ResultButton.Click += new System.EventHandler(this.ResultButton_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            this.OpenFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            // 
            // TextBoxHash
            // 
            this.TextBoxHash.Location = new System.Drawing.Point(461, 315);
            this.TextBoxHash.Multiline = true;
            this.TextBoxHash.Name = "TextBoxHash";
            this.TextBoxHash.ReadOnly = true;
            this.TextBoxHash.Size = new System.Drawing.Size(275, 40);
            this.TextBoxHash.TabIndex = 21;
            // 
            // TextBoxEDS
            // 
            this.TextBoxEDS.Location = new System.Drawing.Point(461, 375);
            this.TextBoxEDS.Multiline = true;
            this.TextBoxEDS.Name = "TextBoxEDS";
            this.TextBoxEDS.ReadOnly = true;
            this.TextBoxEDS.Size = new System.Drawing.Size(275, 48);
            this.TextBoxEDS.TabIndex = 22;
            // 
            // HashLabel
            // 
            this.HashLabel.Location = new System.Drawing.Point(375, 318);
            this.HashLabel.Name = "HashLabel";
            this.HashLabel.Size = new System.Drawing.Size(80, 25);
            this.HashLabel.TabIndex = 23;
            this.HashLabel.Text = "Hash:";
            // 
            // EDSLabel
            // 
            this.EDSLabel.Location = new System.Drawing.Point(375, 375);
            this.EDSLabel.Name = "EDSLabel";
            this.EDSLabel.Size = new System.Drawing.Size(80, 25);
            this.EDSLabel.TabIndex = 24;
            this.EDSLabel.Text = "Sign:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 25;
            this.label1.Text = "D:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(306, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 26;
            this.label2.Text = "E:";
            // 
            // ClearLines
            // 
            this.ClearLines.Location = new System.Drawing.Point(365, 224);
            this.ClearLines.Name = "ClearLines";
            this.ClearLines.Size = new System.Drawing.Size(222, 33);
            this.ClearLines.TabIndex = 27;
            this.ClearLines.Text = "Clear";
            this.ClearLines.UseVisualStyleBackColor = true;
            this.ClearLines.Click += new System.EventHandler(this.ClearLines_Click);
            // 
            // LoadFromFile
            // 
            this.LoadFromFile.Location = new System.Drawing.Point(265, 448);
            this.LoadFromFile.Name = "LoadFromFile";
            this.LoadFromFile.Size = new System.Drawing.Size(157, 62);
            this.LoadFromFile.TabIndex = 28;
            this.LoadFromFile.Text = "LoadFile";
            this.LoadFromFile.UseVisualStyleBackColor = true;
            this.LoadFromFile.Click += new System.EventHandler(this.LoadFromFile_Click);
            // 
            // SaveToFile
            // 
            this.SaveToFile.BackColor = System.Drawing.SystemColors.Control;
            this.SaveToFile.Location = new System.Drawing.Point(467, 448);
            this.SaveToFile.Name = "SaveToFile";
            this.SaveToFile.Size = new System.Drawing.Size(157, 62);
            this.SaveToFile.TabIndex = 29;
            this.SaveToFile.Text = "SaveFile";
            this.SaveToFile.UseVisualStyleBackColor = false;
            this.SaveToFile.Click += new System.EventHandler(this.SaveToFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(834, 780);
            this.Controls.Add(this.SaveToFile);
            this.Controls.Add(this.LoadFromFile);
            this.Controls.Add(this.ClearLines);
            this.Controls.Add(this.EDSLabel);
            this.Controls.Add(this.HashLabel);
            this.Controls.Add(this.TextBoxEDS);
            this.Controls.Add(this.TextBoxHash);
            this.Controls.Add(this.ResultButton);
            this.Controls.Add(this.PlainLabel);
            this.Controls.Add(this.PlainText);
            this.Controls.Add(this.TextBoxE);
            this.Controls.Add(this.RadioButtonCheck);
            this.Controls.Add(this.RadioButtonCreate);
            this.Controls.Add(this.TextBoxEuler);
            this.Controls.Add(this.EulerLabel);
            this.Controls.Add(this.TextBoxD);
            this.Controls.Add(this.ButtonR);
            this.Controls.Add(this.LabelR);
            this.Controls.Add(this.TextBoxR);
            this.Controls.Add(this.TextBoxQ);
            this.Controls.Add(this.LabelQ);
            this.Controls.Add(this.TextBoxP);
            this.Controls.Add(this.LabelP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ТИ ЛР4";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox TextBoxHash;
        private System.Windows.Forms.TextBox TextBoxEDS;
        private System.Windows.Forms.Label HashLabel;
        private System.Windows.Forms.Label EDSLabel;

        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;

        private System.Windows.Forms.Button ResultButton;

        private System.Windows.Forms.TextBox PlainText;

        private System.Windows.Forms.Label PlainLabel;

        private System.Windows.Forms.TextBox TextBoxD;

        private System.Windows.Forms.RadioButton RadioButtonCreate;
        private System.Windows.Forms.RadioButton RadioButtonCheck;

        private System.Windows.Forms.Label EulerLabel;

        private System.Windows.Forms.TextBox TextBoxE;
        private System.Windows.Forms.TextBox TextBoxEuler;

        private System.Windows.Forms.Button ButtonR;
        private System.Windows.Forms.Label LabelP;
        private System.Windows.Forms.TextBox TextBoxP;
        private System.Windows.Forms.TextBox TextBoxQ;
        private System.Windows.Forms.Label LabelQ;
        private System.Windows.Forms.TextBox TextBoxR;
        private System.Windows.Forms.Label LabelR;

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ClearLines;
        private System.Windows.Forms.Button LoadFromFile;
        private System.Windows.Forms.Button SaveToFile;
    }
}