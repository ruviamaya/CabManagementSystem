namespace CB011911
{
    partial class ManageVehicle
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
            button1.Location = new Point(70, 108);
            button1.Name = "button1";
            button1.Size = new Size(131, 50);
            button1.TabIndex = 0;
            button1.Text = "Add New Vehicle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(248, 108);
            button2.Name = "button2";
            button2.Size = new Size(172, 50);
            button2.TabIndex = 1;
            button2.Text = "Delete/Update/View Vehicle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(25, 22);
            label1.Name = "label1";
            label1.Size = new Size(52, 17);
            label1.TabIndex = 2;
            label1.Text = "Go Back";
            label1.Click += label1_Click;
            // 
            // ManageVehicle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 252);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "ManageVehicle";
            Text = "ManageVehicle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
    }
}