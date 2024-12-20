namespace CB011911
{
    partial class ManageDrivers
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
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(74, 105);
            button1.Name = "button1";
            button1.Size = new Size(126, 49);
            button1.TabIndex = 0;
            button1.Text = "Add New Driver";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(245, 105);
            button2.Name = "button2";
            button2.Size = new Size(172, 49);
            button2.TabIndex = 1;
            button2.Text = "Delete/Update/View Driver";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(26, 24);
            label1.Name = "label1";
            label1.Size = new Size(52, 17);
            label1.TabIndex = 2;
            label1.Text = "Go Back";
            label1.Click += label1_Click;
            // 
            // ManageDrivers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 244);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "ManageDrivers";
            Text = "ManageDrivers";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
    }
}