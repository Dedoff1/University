namespace Lab_2
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
            this.tbAmountOfShapes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnExecuteKMeansAlgorithm = new System.Windows.Forms.Button();
            this.btnExecuteMaximinsAlgorithm = new System.Windows.Forms.Button();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.gbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbAmountOfShapes
            // 
            this.tbAmountOfShapes.Location = new System.Drawing.Point(18, 71);
            this.tbAmountOfShapes.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbAmountOfShapes.Name = "tbAmountOfShapes";
            this.tbAmountOfShapes.Size = new System.Drawing.Size(366, 31);
            this.tbAmountOfShapes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dots:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(499, 40);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(388, 73);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Create";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(24, 121);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(974, 561);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // btnExecuteKMeansAlgorithm
            // 
            this.btnExecuteKMeansAlgorithm.Enabled = false;
            this.btnExecuteKMeansAlgorithm.Location = new System.Drawing.Point(1010, 449);
            this.btnExecuteKMeansAlgorithm.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnExecuteKMeansAlgorithm.Name = "btnExecuteKMeansAlgorithm";
            this.btnExecuteKMeansAlgorithm.Size = new System.Drawing.Size(243, 103);
            this.btnExecuteKMeansAlgorithm.TabIndex = 4;
            this.btnExecuteKMeansAlgorithm.Text = "K-Means";
            this.btnExecuteKMeansAlgorithm.UseVisualStyleBackColor = true;
            this.btnExecuteKMeansAlgorithm.Visible = false;
            this.btnExecuteKMeansAlgorithm.Click += new System.EventHandler(this.btnExecuteKMeansAlgorithm_Click);
            // 
            // btnExecuteMaximinsAlgorithm
            // 
            this.btnExecuteMaximinsAlgorithm.Location = new System.Drawing.Point(1010, 245);
            this.btnExecuteMaximinsAlgorithm.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnExecuteMaximinsAlgorithm.Name = "btnExecuteMaximinsAlgorithm";
            this.btnExecuteMaximinsAlgorithm.Size = new System.Drawing.Size(243, 103);
            this.btnExecuteMaximinsAlgorithm.TabIndex = 5;
            this.btnExecuteMaximinsAlgorithm.Text = "Maximin\'s";
            this.btnExecuteMaximinsAlgorithm.UseVisualStyleBackColor = true;
            this.btnExecuteMaximinsAlgorithm.Click += new System.EventHandler(this.btnExecuteMaximinsAlgorithm_Click);
            // 
            // gbSettings
            // 
            this.gbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSettings.BackColor = System.Drawing.SystemColors.Info;
            this.gbSettings.Controls.Add(this.label1);
            this.gbSettings.Controls.Add(this.tbAmountOfShapes);
            this.gbSettings.Controls.Add(this.btnGenerate);
            this.gbSettings.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gbSettings.Location = new System.Drawing.Point(10, 0);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbSettings.Size = new System.Drawing.Size(1534, 121);
            this.gbSettings.TabIndex = 6;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1568, 1079);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.btnExecuteMaximinsAlgorithm);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnExecuteKMeansAlgorithm);
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maximin\'s";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TextBox tbAmountOfShapes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnExecuteKMeansAlgorithm;
        private System.Windows.Forms.Button btnExecuteMaximinsAlgorithm;
        private System.Windows.Forms.GroupBox gbSettings;
    }
}