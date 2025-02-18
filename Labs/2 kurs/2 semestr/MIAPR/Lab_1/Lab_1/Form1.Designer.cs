namespace Lab_1
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
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnExecuteAlgorithm = new System.Windows.Forms.Button();
            this.tbAmountOfShapes = new System.Windows.Forms.TextBox();
            this.tbAmountOfClasses = new System.Windows.Forms.TextBox();
            this.shapeLabel = new System.Windows.Forms.Label();
            this.classLabel = new System.Windows.Forms.Label();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.gbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCanvas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pbCanvas.Location = new System.Drawing.Point(24, 158);
            this.pbCanvas.Margin = new System.Windows.Forms.Padding(6);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(916, 700);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;
            // 
            // btnGenerate
            // 
            this.btnGenerate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnGenerate.Location = new System.Drawing.Point(994, 247);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(6);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(180, 94);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Create";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnExecuteAlgorithm
            // 
            this.btnExecuteAlgorithm.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnExecuteAlgorithm.Location = new System.Drawing.Point(994, 398);
            this.btnExecuteAlgorithm.Margin = new System.Windows.Forms.Padding(6);
            this.btnExecuteAlgorithm.Name = "btnExecuteAlgorithm";
            this.btnExecuteAlgorithm.Size = new System.Drawing.Size(180, 78);
            this.btnExecuteAlgorithm.TabIndex = 2;
            this.btnExecuteAlgorithm.Text = "K-means";
            this.btnExecuteAlgorithm.UseVisualStyleBackColor = true;
            this.btnExecuteAlgorithm.Click += new System.EventHandler(this.btnKMeans_Click);
            // 
            // tbAmountOfShapes
            // 
            this.tbAmountOfShapes.Location = new System.Drawing.Point(332, 81);
            this.tbAmountOfShapes.Margin = new System.Windows.Forms.Padding(6);
            this.tbAmountOfShapes.Name = "tbAmountOfShapes";
            this.tbAmountOfShapes.Size = new System.Drawing.Size(232, 31);
            this.tbAmountOfShapes.TabIndex = 3;
            this.tbAmountOfShapes.TextChanged += new System.EventHandler(this.tbAmountOfShapes_TextChanged);
            // 
            // tbAmountOfClasses
            // 
            this.tbAmountOfClasses.Location = new System.Drawing.Point(936, 81);
            this.tbAmountOfClasses.Margin = new System.Windows.Forms.Padding(6);
            this.tbAmountOfClasses.Name = "tbAmountOfClasses";
            this.tbAmountOfClasses.Size = new System.Drawing.Size(214, 31);
            this.tbAmountOfClasses.TabIndex = 4;
            this.tbAmountOfClasses.TextChanged += new System.EventHandler(this.tbAmountOfClasses_TextChanged);
            // 
            // shapeLabel
            // 
            this.shapeLabel.AutoSize = true;
            this.shapeLabel.Location = new System.Drawing.Point(403, 50);
            this.shapeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.shapeLabel.Name = "shapeLabel";
            this.shapeLabel.Size = new System.Drawing.Size(62, 25);
            this.shapeLabel.TabIndex = 5;
            this.shapeLabel.Text = "Dots:";
            // 
            // classLabel
            // 
            this.classLabel.AutoSize = true;
            this.classLabel.Location = new System.Drawing.Point(1003, 50);
            this.classLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(95, 25);
            this.classLabel.TabIndex = 6;
            this.classLabel.Text = "Classes:";
            // 
            // gbSettings
            // 
            this.gbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSettings.BackColor = System.Drawing.SystemColors.Info;
            this.gbSettings.Controls.Add(this.shapeLabel);
            this.gbSettings.Controls.Add(this.tbAmountOfClasses);
            this.gbSettings.Controls.Add(this.classLabel);
            this.gbSettings.Controls.Add(this.tbAmountOfShapes);
            this.gbSettings.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gbSettings.Location = new System.Drawing.Point(24, 15);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(6);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(6);
            this.gbSettings.Size = new System.Drawing.Size(1520, 138);
            this.gbSettings.TabIndex = 7;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1494, 1079);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.pbCanvas);
            this.Controls.Add(this.btnExecuteAlgorithm);
            this.Controls.Add(this.btnGenerate);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "K-means";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnExecuteAlgorithm;
        private System.Windows.Forms.TextBox tbAmountOfShapes;
        private System.Windows.Forms.TextBox tbAmountOfClasses;
        private System.Windows.Forms.Label shapeLabel;
        private System.Windows.Forms.Label classLabel;
        private System.Windows.Forms.GroupBox gbSettings;
    }
}