namespace DD_Admin
{
    partial class Head_main
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
            label1 = new Label();
            exit = new Label();
            panel2 = new Panel();
            Back = new Button();
            pictureBox1 = new PictureBox();
            footwear_btn = new Button();
            dashboard_btn = new Button();
            label2 = new Label();
            panel3 = new Panel();
            dFootwear11 = new dFootwear1();
            dashbaoard13 = new dashbaoard1();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 53, 84);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(exit);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1100, 35);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 6);
            label1.Name = "label1";
            label1.Size = new Size(261, 19);
            label1.TabIndex = 2;
            label1.Text = "Footwear Management System";
            // 
            // exit
            // 
            exit.AutoSize = true;
            exit.Cursor = Cursors.Hand;
            exit.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exit.ForeColor = SystemColors.ButtonHighlight;
            exit.Location = new Point(1071, 9);
            exit.Name = "exit";
            exit.Size = new Size(17, 18);
            exit.TabIndex = 1;
            exit.Text = "X";
            exit.Click += exit_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 48, 73);
            panel2.Controls.Add(Back);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(footwear_btn);
            panel2.Controls.Add(dashboard_btn);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 35);
            panel2.Name = "panel2";
            panel2.Size = new Size(225, 565);
            panel2.TabIndex = 1;
            // 
            // Back
            // 
            Back.FlatAppearance.BorderSize = 0;
            Back.FlatStyle = FlatStyle.Flat;
            Back.Image = Properties.Resources.icons8_back_button_50__1_;
            Back.Location = new Point(12, 525);
            Back.Name = "Back";
            Back.Size = new Size(28, 28);
            Back.TabIndex = 7;
            Back.UseVisualStyleBackColor = true;
            Back.Click += Back_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_employee_100__1_;
            pictureBox1.Location = new Point(59, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // footwear_btn
            // 
            footwear_btn.BackColor = Color.FromArgb(0, 48, 73);
            footwear_btn.FlatStyle = FlatStyle.Flat;
            footwear_btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            footwear_btn.ForeColor = Color.White;
            footwear_btn.Image = Properties.Resources.icons8_sneakers_50;
            footwear_btn.ImageAlign = ContentAlignment.MiddleLeft;
            footwear_btn.Location = new Point(12, 295);
            footwear_btn.Name = "footwear_btn";
            footwear_btn.Size = new Size(200, 40);
            footwear_btn.TabIndex = 2;
            footwear_btn.Text = "FOOTWEAR";
            footwear_btn.UseVisualStyleBackColor = false;
            footwear_btn.Click += footwear_btn_Click_1;
            // 
            // dashboard_btn
            // 
            dashboard_btn.BackColor = Color.FromArgb(0, 48, 73);
            dashboard_btn.FlatStyle = FlatStyle.Flat;
            dashboard_btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dashboard_btn.ForeColor = Color.White;
            dashboard_btn.Image = Properties.Resources.icons8_dashboard_50__3_;
            dashboard_btn.ImageAlign = ContentAlignment.MiddleLeft;
            dashboard_btn.Location = new Point(12, 235);
            dashboard_btn.Name = "dashboard_btn";
            dashboard_btn.Size = new Size(200, 40);
            dashboard_btn.TabIndex = 1;
            dashboard_btn.Text = "DASHBOARD";
            dashboard_btn.UseVisualStyleBackColor = false;
            dashboard_btn.Click += dashboard_btn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(59, 158);
            label2.Name = "label2";
            label2.Size = new Size(110, 21);
            label2.TabIndex = 0;
            label2.Text = "Welcome User";
            // 
            // panel3
            // 
            panel3.Controls.Add(dashbaoard13);
            panel3.Controls.Add(dFootwear11);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(225, 35);
            panel3.Name = "panel3";
            panel3.Size = new Size(875, 565);
            panel3.TabIndex = 2;
            // 
            // dFootwear11
            // 
            dFootwear11.Location = new Point(0, 0);
            dFootwear11.Name = "dFootwear11";
            dFootwear11.Size = new Size(875, 565);
            dFootwear11.TabIndex = 0;
            // 
            // dashbaoard13
            // 
            dashbaoard13.Location = new Point(0, 0);
            dashbaoard13.Name = "dashbaoard13";
            dashbaoard13.Size = new Size(875, 565);
            dashbaoard13.TabIndex = 1;
            // 
            // Head_main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 600);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Head_main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Head_main";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label exit;
        private Label label1;
        private Panel panel2;
        private Button dashboard_btn;
        private Label label2;
        private Button footwear_btn;
        private PictureBox pictureBox1;
        private Button Back;
        private Panel dashbaoard1;
        private DOutlet dOutlet1;
        private dFootwear1 dFootwear1;
        private dashbaoard1 dashbaoard11;
        private DThirdparty dThirdparty1;
        private DOutlet dOutlet2;
        private dashbaoard1 dashbaoard12;
        private dFootwear1 dFootwear2;
        private Panel panel3;
        private dashbaoard1 dashbaoard13;
        private dFootwear1 dFootwear11;
    }
}