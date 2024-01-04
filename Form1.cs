namespace DD_Admin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Head_login loginForm = new Head_login();
            loginForm.Show();
            this.Hide();
        }

        private void outlet_btn_Click(object sender, EventArgs e)
        {
            Outlet_login loginForm = new Outlet_login();
            loginForm.Show();
            this.Hide();
        }

        private void Thirdpaty_btn_Click(object sender, EventArgs e)
        {
            Thirdpty_login loginForm = new Thirdpty_login();
            loginForm.Show();
            this.Hide();
        }
    }
}
