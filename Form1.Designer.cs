namespace DD_Admin
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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            exit = new Label();
            Head_btn = new Button();
            outlet_btn = new Button();
            Thirdpaty_btn = new Button();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 53, 84);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 400);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.White_Elegant_Feminine_Fashion_Logo;
            pictureBox1.Location = new Point(11, 111);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(176, 177);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // exit
            // 
            exit.AutoSize = true;
            exit.Cursor = Cursors.Hand;
            exit.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exit.Location = new Point(545, 9);
            exit.Name = "exit";
            exit.Size = new Size(18, 19);
            exit.TabIndex = 1;
            exit.Text = "X";
            exit.Click += label1_Click;
            // 
            // Head_btn
            // 
            Head_btn.BackColor = Color.FromArgb(14, 107, 168);
            Head_btn.FlatAppearance.BorderSize = 0;
            Head_btn.FlatStyle = FlatStyle.Flat;
            Head_btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Head_btn.ForeColor = SystemColors.ButtonFace;
            Head_btn.Location = new Point(295, 126);
            Head_btn.Name = "Head_btn";
            Head_btn.Size = new Size(185, 39);
            Head_btn.TabIndex = 2;
            Head_btn.Text = "Head Office";
            Head_btn.UseVisualStyleBackColor = false;
            Head_btn.Click += button1_Click;
            // 
            // outlet_btn
            // 
            outlet_btn.BackColor = Color.FromArgb(5, 130, 202);
            outlet_btn.Cursor = Cursors.Hand;
            outlet_btn.FlatStyle = FlatStyle.Flat;
            outlet_btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            outlet_btn.ForeColor = SystemColors.ButtonFace;
            outlet_btn.Location = new Point(295, 188);
            outlet_btn.Name = "outlet_btn";
            outlet_btn.Size = new Size(185, 39);
            outlet_btn.TabIndex = 3;
            outlet_btn.Text = "Outlet";
            outlet_btn.UseVisualStyleBackColor = false;
            outlet_btn.Click += outlet_btn_Click;
            // 
            // Thirdpaty_btn
            // 
            Thirdpaty_btn.BackColor = Color.FromArgb(66, 202, 253);
            Thirdpaty_btn.Cursor = Cursors.Hand;
            Thirdpaty_btn.FlatStyle = FlatStyle.Flat;
            Thirdpaty_btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Thirdpaty_btn.ForeColor = SystemColors.ButtonHighlight;
            Thirdpaty_btn.Location = new Point(295, 250);
            Thirdpaty_btn.Name = "Thirdpaty_btn";
            Thirdpaty_btn.Size = new Size(185, 39);
            Thirdpaty_btn.TabIndex = 5;
            Thirdpaty_btn.Text = "Third party";
            Thirdpaty_btn.UseVisualStyleBackColor = false;
            Thirdpaty_btn.Click += Thirdpaty_btn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(272, 59);
            label2.Name = "label2";
            label2.Size = new Size(223, 23);
            label2.TabIndex = 6;
            label2.Text = "Welcome to DD Footwear";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(575, 400);
            Controls.Add(label2);
            Controls.Add(Thirdpaty_btn);
            Controls.Add(outlet_btn);
            Controls.Add(Head_btn);
            Controls.Add(exit);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "   ";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label exit;
        private Button Head_btn;
        private Button outlet_btn;
        private Button Thirdpaty_btn;
        private Label label2;
        private PictureBox pictureBox1;
    }
}
