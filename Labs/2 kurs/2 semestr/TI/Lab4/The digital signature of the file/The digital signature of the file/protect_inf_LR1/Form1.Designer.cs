﻿namespace protect_inf_LR1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.signButton = new System.Windows.Forms.Button();
            this.checkSignButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_p = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_q = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_d = new System.Windows.Forms.TextBox();
            this.textBox_n = new System.Windows.Forms.TextBox();
            this.sourceFilePathTextBox = new System.Windows.Forms.TextBox();
            this.signFilePathTextBox = new System.Windows.Forms.TextBox();
            this.sourceFileButton = new System.Windows.Forms.Button();
            this.signFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // signButton
            // 
            this.signButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.signButton.Location = new System.Drawing.Point(48, 425);
            this.signButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.signButton.Name = "signButton";
            this.signButton.Size = new System.Drawing.Size(414, 92);
            this.signButton.TabIndex = 1;
            this.signButton.Text = "Подписать";
            this.signButton.UseVisualStyleBackColor = true;
            this.signButton.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // checkSignButton
            // 
            this.checkSignButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkSignButton.Location = new System.Drawing.Point(750, 425);
            this.checkSignButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.checkSignButton.Name = "checkSignButton";
            this.checkSignButton.Size = new System.Drawing.Size(414, 92);
            this.checkSignButton.TabIndex = 2;
            this.checkSignButton.Text = "Проверить подлинность подписи";
            this.checkSignButton.UseVisualStyleBackColor = true;
            this.checkSignButton.Click += new System.EventHandler(this.buttonDecipher_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(40, 338);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "p =";
            // 
            // textBox_p
            // 
            this.textBox_p.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_p.Location = new System.Drawing.Point(114, 333);
            this.textBox_p.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox_p.Name = "textBox_p";
            this.textBox_p.Size = new System.Drawing.Size(120, 44);
            this.textBox_p.TabIndex = 4;
            this.textBox_p.Text = "101";
            this.textBox_p.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(264, 338);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "q =";
            // 
            // textBox_q
            // 
            this.textBox_q.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_q.Location = new System.Drawing.Point(338, 333);
            this.textBox_q.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox_q.Name = "textBox_q";
            this.textBox_q.Size = new System.Drawing.Size(120, 44);
            this.textBox_q.TabIndex = 6;
            this.textBox_q.Text = "103";
            this.textBox_q.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(136, 262);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 37);
            this.label3.TabIndex = 7;
            this.label3.Text = "Простые числа";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(742, 338);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 37);
            this.label4.TabIndex = 8;
            this.label4.Text = "d =";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(966, 338);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 37);
            this.label5.TabIndex = 9;
            this.label5.Text = "n =";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(836, 262);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(247, 37);
            this.label6.TabIndex = 10;
            this.label6.Text = "Секретный ключ";
            // 
            // textBox_d
            // 
            this.textBox_d.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_d.Location = new System.Drawing.Point(816, 333);
            this.textBox_d.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox_d.Name = "textBox_d";
            this.textBox_d.Size = new System.Drawing.Size(120, 44);
            this.textBox_d.TabIndex = 11;
            this.textBox_d.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_n
            // 
            this.textBox_n.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_n.Location = new System.Drawing.Point(1040, 333);
            this.textBox_n.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox_n.Name = "textBox_n";
            this.textBox_n.Size = new System.Drawing.Size(120, 44);
            this.textBox_n.TabIndex = 12;
            this.textBox_n.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sourceFilePathTextBox
            // 
            this.sourceFilePathTextBox.Enabled = false;
            this.sourceFilePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.sourceFilePathTextBox.Location = new System.Drawing.Point(24, 42);
            this.sourceFilePathTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.sourceFilePathTextBox.Name = "sourceFilePathTextBox";
            this.sourceFilePathTextBox.Size = new System.Drawing.Size(832, 41);
            this.sourceFilePathTextBox.TabIndex = 13;
            // 
            // signFilePathTextBox
            // 
            this.signFilePathTextBox.Enabled = false;
            this.signFilePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.signFilePathTextBox.Location = new System.Drawing.Point(24, 154);
            this.signFilePathTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.signFilePathTextBox.Name = "signFilePathTextBox";
            this.signFilePathTextBox.Size = new System.Drawing.Size(832, 41);
            this.signFilePathTextBox.TabIndex = 14;
            // 
            // sourceFileButton
            // 
            this.sourceFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.sourceFileButton.Location = new System.Drawing.Point(934, 38);
            this.sourceFileButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.sourceFileButton.Name = "sourceFileButton";
            this.sourceFileButton.Size = new System.Drawing.Size(300, 56);
            this.sourceFileButton.TabIndex = 15;
            this.sourceFileButton.Text = "Исходный файл";
            this.sourceFileButton.UseVisualStyleBackColor = true;
            this.sourceFileButton.Click += new System.EventHandler(this.sourceFileButton_Click);
            // 
            // signFileButton
            // 
            this.signFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.signFileButton.Location = new System.Drawing.Point(934, 148);
            this.signFileButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.signFileButton.Name = "signFileButton";
            this.signFileButton.Size = new System.Drawing.Size(300, 58);
            this.signFileButton.TabIndex = 16;
            this.signFileButton.Text = "Файл с подписью";
            this.signFileButton.UseVisualStyleBackColor = true;
            this.signFileButton.Click += new System.EventHandler(this.signFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 560);
            this.Controls.Add(this.signFileButton);
            this.Controls.Add(this.sourceFileButton);
            this.Controls.Add(this.signFilePathTextBox);
            this.Controls.Add(this.sourceFilePathTextBox);
            this.Controls.Add(this.textBox_n);
            this.Controls.Add(this.textBox_d);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_q);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_p);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkSignButton);
            this.Controls.Add(this.signButton);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "vscode.ru - электронная подпись";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button signButton;
        private System.Windows.Forms.Button checkSignButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_p;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_q;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_d;
        private System.Windows.Forms.TextBox textBox_n;
        private System.Windows.Forms.TextBox sourceFilePathTextBox;
        private System.Windows.Forms.TextBox signFilePathTextBox;
        private System.Windows.Forms.Button sourceFileButton;
        private System.Windows.Forms.Button signFileButton;
    }
}

