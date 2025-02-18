namespace Lab_3
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tbProbabilityOfMissingErrorDetection = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFalseAlarmProbability = new System.Windows.Forms.TextBox();
            this.tbFirstProbability = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSecondProbability = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbProbabilityOfTotalClassificationError = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClassify = new System.Windows.Forms.Button();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.gbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(94, 246);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1015, 579);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // tbProbabilityOfMissingErrorDetection
            // 
            this.tbProbabilityOfMissingErrorDetection.Enabled = false;
            this.tbProbabilityOfMissingErrorDetection.Location = new System.Drawing.Point(740, 107);
            this.tbProbabilityOfMissingErrorDetection.Margin = new System.Windows.Forms.Padding(6);
            this.tbProbabilityOfMissingErrorDetection.Name = "tbProbabilityOfMissingErrorDetection";
            this.tbProbabilityOfMissingErrorDetection.Size = new System.Drawing.Size(366, 31);
            this.tbProbabilityOfMissingErrorDetection.TabIndex = 5;
            this.tbProbabilityOfMissingErrorDetection.TextChanged += new System.EventHandler(this.tbProbabilityOfMissingErrorDetection_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(735, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(367, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Probability of missing error detection:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(735, 147);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(371, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Probability of total classification error:";
            // 
            // tbFalseAlarmProbability
            // 
            this.tbFalseAlarmProbability.Enabled = false;
            this.tbFalseAlarmProbability.Location = new System.Drawing.Point(740, 40);
            this.tbFalseAlarmProbability.Margin = new System.Windows.Forms.Padding(6);
            this.tbFalseAlarmProbability.Name = "tbFalseAlarmProbability";
            this.tbFalseAlarmProbability.Size = new System.Drawing.Size(366, 31);
            this.tbFalseAlarmProbability.TabIndex = 4;
            // 
            // tbFirstProbability
            // 
            this.tbFirstProbability.Location = new System.Drawing.Point(17, 61);
            this.tbFirstProbability.Margin = new System.Windows.Forms.Padding(6);
            this.tbFirstProbability.Name = "tbFirstProbability";
            this.tbFirstProbability.Size = new System.Drawing.Size(366, 31);
            this.tbFirstProbability.TabIndex = 1;
            this.tbFirstProbability.Text = "0.4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(407, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Probability 2:";
            // 
            // tbSecondProbability
            // 
            this.tbSecondProbability.Location = new System.Drawing.Point(17, 129);
            this.tbSecondProbability.Margin = new System.Windows.Forms.Padding(6);
            this.tbSecondProbability.Name = "tbSecondProbability";
            this.tbSecondProbability.Size = new System.Drawing.Size(366, 31);
            this.tbSecondProbability.TabIndex = 2;
            this.tbSecondProbability.Text = "0.6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(735, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "False alarm probability:";
            // 
            // tbProbabilityOfTotalClassificationError
            // 
            this.tbProbabilityOfTotalClassificationError.Enabled = false;
            this.tbProbabilityOfTotalClassificationError.Location = new System.Drawing.Point(740, 178);
            this.tbProbabilityOfTotalClassificationError.Margin = new System.Windows.Forms.Padding(6);
            this.tbProbabilityOfTotalClassificationError.Name = "tbProbabilityOfTotalClassificationError";
            this.tbProbabilityOfTotalClassificationError.Size = new System.Drawing.Size(366, 31);
            this.tbProbabilityOfTotalClassificationError.TabIndex = 6;
            this.tbProbabilityOfTotalClassificationError.TextChanged += new System.EventHandler(this.tbProbabilityOfTotalClassificationError_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(407, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Probability 1:";
            // 
            // btnClassify
            // 
            this.btnClassify.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnClassify.Location = new System.Drawing.Point(17, 178);
            this.btnClassify.Margin = new System.Windows.Forms.Padding(6);
            this.btnClassify.Name = "btnClassify";
            this.btnClassify.Size = new System.Drawing.Size(370, 44);
            this.btnClassify.TabIndex = 0;
            this.btnClassify.Text = "Classify";
            this.btnClassify.UseVisualStyleBackColor = true;
            this.btnClassify.Click += new System.EventHandler(this.btnClassify_Click);
            // 
            // gbSettings
            // 
            this.gbSettings.BackColor = System.Drawing.SystemColors.Info;
            this.gbSettings.Controls.Add(this.btnClassify);
            this.gbSettings.Controls.Add(this.label1);
            this.gbSettings.Controls.Add(this.tbProbabilityOfTotalClassificationError);
            this.gbSettings.Controls.Add(this.label3);
            this.gbSettings.Controls.Add(this.tbSecondProbability);
            this.gbSettings.Controls.Add(this.label2);
            this.gbSettings.Controls.Add(this.tbFirstProbability);
            this.gbSettings.Controls.Add(this.tbFalseAlarmProbability);
            this.gbSettings.Controls.Add(this.label5);
            this.gbSettings.Controls.Add(this.label4);
            this.gbSettings.Controls.Add(this.tbProbabilityOfMissingErrorDetection);
            this.gbSettings.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gbSettings.Location = new System.Drawing.Point(77, 0);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(6);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(6);
            this.gbSettings.Size = new System.Drawing.Size(1158, 234);
            this.gbSettings.TabIndex = 12;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1588, 830);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MainForm";
            this.Text = "Lab_3";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox tbProbabilityOfMissingErrorDetection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFalseAlarmProbability;
        private System.Windows.Forms.TextBox tbFirstProbability;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSecondProbability;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbProbabilityOfTotalClassificationError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClassify;
        private System.Windows.Forms.GroupBox gbSettings;
    }
}

