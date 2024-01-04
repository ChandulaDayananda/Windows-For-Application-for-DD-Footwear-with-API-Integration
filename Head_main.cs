using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DD_Admin
{
    public partial class Head_main : Form
    {

        public Head_main()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void RefreshDashboard()
        {
            LoadDashboardData();
        }
        private void LoadDashboardData()
        {

        }


        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            dashbaoard13.Visible = true;
            dFootwear11.Visible = false;
            RefreshDashboard();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Form1 HeadForm = new Form1();
            HeadForm.Show();
            this.Hide();
        }

        
        private void footwear_btn_Click_1(object sender, EventArgs e)
        {
            dashbaoard13.Visible = false;
            dFootwear11.Visible = true;
            RefreshDashboard();
        }
    }
}
