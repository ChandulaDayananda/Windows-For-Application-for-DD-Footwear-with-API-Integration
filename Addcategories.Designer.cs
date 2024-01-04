namespace DD_Admin
{
    partial class addcategories1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            button1 = new Button();
            addcategories11 = new Panel();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            addcategories11.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(36, 91);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(772, 145);
            dataGridView1.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(240, 286);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(222, 23);
            textBox1.TabIndex = 10;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 48, 73);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(483, 286);
            button1.Name = "button1";
            button1.Size = new Size(75, 33);
            button1.TabIndex = 11;
            button1.Text = "SUBMIT";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // addcategories11
            // 
            addcategories11.BackColor = SystemColors.ButtonHighlight;
            addcategories11.Controls.Add(button1);
            addcategories11.Controls.Add(textBox1);
            addcategories11.Controls.Add(dataGridView1);
            addcategories11.Controls.Add(label5);
            addcategories11.Location = new Point(0, 0);
            addcategories11.Name = "addcategories11";
            addcategories11.Size = new Size(837, 350);
            addcategories11.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(21, 32);
            label5.Name = "label5";
            label5.Size = new Size(271, 23);
            label5.TabIndex = 6;
            label5.Text = "FOOTWAER WEBSITE ORDERS";
            // 
            // addcategories1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(addcategories11);
            Name = "addcategories1";
            Size = new Size(837, 350);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            addcategories11.ResumeLayout(false);
            addcategories11.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Button button1;
        private Panel addfootwaer1;
        private Label label5;
        private Panel addcategories11;
    }
}
