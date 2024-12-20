namespace CB011911
{
    partial class DriverDashboard
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
            button2 = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(164, 180);
            button2.Name = "button2";
            button2.Size = new Size(123, 51);
            button2.TabIndex = 1;
            button2.Text = "View Trips";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(136, 70);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(73, 19);
            radioButton1.TabIndex = 4;
            radioButton1.TabStop = true;
            radioButton1.Text = "Available";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(234, 70);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(86, 19);
            radioButton2.TabIndex = 5;
            radioButton2.TabStop = true;
            radioButton2.Text = "Unavailable";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(12, 12);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 6;
            button4.Text = "Logout";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(164, 108);
            button5.Name = "button5";
            button5.Size = new Size(123, 32);
            button5.TabIndex = 7;
            button5.Text = "Update Availability";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // DriverDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(456, 298);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(button2);
            Name = "DriverDashboard";
            Text = "DriverDashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Button button4;
        private Button button5;
    }
}