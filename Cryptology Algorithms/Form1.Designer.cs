namespace Cryptology_Algorithms
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(111, 39);
            label1.Name = "label1";
            label1.Size = new Size(226, 46);
            label1.TabIndex = 0;
            label1.Text = "ALGORITHMS";
            // 
            // button1
            // 
            button1.Location = new Point(163, 110);
            button1.Name = "button1";
            button1.Size = new Size(119, 29);
            button1.TabIndex = 1;
            button1.Text = "Transposition";
            button1.UseVisualStyleBackColor = true;
            button1.Click += transposition_Click;
            // 
            // button2
            // 
            button2.Location = new Point(139, 156);
            button2.Name = "button2";
            button2.Size = new Size(168, 29);
            button2.TabIndex = 2;
            button2.Text = "Permutation Cipher";
            button2.UseVisualStyleBackColor = true;
            button2.Click += permutation_CLick;
            // 
            // button3
            // 
            button3.Location = new Point(175, 208);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 3;
            button3.Text = "Vigenere";
            button3.UseVisualStyleBackColor = true;
            button3.Click += vigenere_Click;
            // 
            // button4
            // 
            button4.Location = new Point(175, 259);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 4;
            button4.Text = "Caeser";
            button4.UseVisualStyleBackColor = true;
            button4.Click += caeser_Click;
            // 
            // button5
            // 
            button5.Location = new Point(175, 312);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 5;
            button5.Text = "Zig Zag";
            button5.UseVisualStyleBackColor = true;
            button5.Click += zig_zag_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(461, 388);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}