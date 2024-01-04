namespace DD_Admin
{
    partial class Thirdpty_login
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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            checkBox1 = new CheckBox();
            login_btn = new Button();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            exit = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(1, 79, 134);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 400);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_lock_144;
            pictureBox1.Location = new Point(32, 128);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 122);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(423, 245);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(108, 19);
            checkBox1.TabIndex = 16;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // login_btn
            // 
            login_btn.BackColor = Color.FromArgb(1, 79, 134);
            login_btn.FlatAppearance.BorderSize = 0;
            login_btn.FlatStyle = FlatStyle.Flat;
            login_btn.ForeColor = SystemColors.ButtonHighlight;
            login_btn.Location = new Point(251, 286);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(76, 29);
            login_btn.TabIndex = 15;
            login_btn.Text = "LOGIN";
            login_btn.UseVisualStyleBackColor = false;
            login_btn.Click += login_btn_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Microsoft Sans Serif", 11.25F);
            textBox2.Location = new Point(251, 215);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(280, 24);
            textBox2.TabIndex = 14;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(251, 196);
            label3.Name = "label3";
            label3.Size = new Size(71, 16);
            label3.TabIndex = 13;
            label3.Text = "Password :";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Microsoft Sans Serif", 11.25F);
            textBox1.Location = new Point(251, 161);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(280, 24);
            textBox1.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(251, 142);
            label2.Name = "label2";
            label2.Size = new Size(74, 16);
            label2.TabIndex = 11;
            label2.Text = "Username :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(231, 63);
            label1.Name = "label1";
            label1.Size = new Size(141, 22);
            label1.TabIndex = 10;
            label1.Text = "Login Account";
            // 
            // exit
            // 
            exit.AutoSize = true;
            exit.Cursor = Cursors.Hand;
            exit.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exit.Location = new Point(546, 9);
            exit.Name = "exit";
            exit.Size = new Size(18, 19);
            exit.TabIndex = 18;
            exit.Text = "X";
            exit.Click += exit_Click;
            // 
            // Thirdpty_login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(575, 400);
            Controls.Add(exit);
            Controls.Add(checkBox1);
            Controls.Add(panel1);
            Controls.Add(login_btn);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Thirdpty_login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thirdpty_login";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private CheckBox checkBox1;
        private Button login_btn;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private Label exit;
        private PictureBox pictureBox1;
    }
}