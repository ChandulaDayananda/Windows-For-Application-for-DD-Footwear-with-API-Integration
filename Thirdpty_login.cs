using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DD_Admin
{
    public partial class Thirdpty_login : Form
    {
        public Thirdpty_login()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            // Define expected username and password
            string expectedUsername = "admin";
            string expectedPassword = "admin";

            string enteredUsername = textBox1.Text.Trim();
            string enteredPassword = textBox2.Text.Trim();

            // Check if the entered credentials are correct
            if (enteredUsername == expectedUsername && enteredPassword == expectedPassword)
            {
                // Credentials are correct, show the Head_main form
                Outlet_main HeadForm = new Outlet_main();
                HeadForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
