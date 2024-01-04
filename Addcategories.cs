using DD_Admin.Models;
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
    public partial class addcategories1 : UserControl
    {
        public addcategories1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient clint = new HttpClient();
            clint.BaseAddress = new Uri("https://localhost:44390/api/");
            HttpResponseMessage respose = clint.GetAsync("CustomerOrders").Result;
            var emp = respose.Content.ReadAsAsync<IEnumerable<CustomerOrdersDet>>().Result;
            dataGridView1.DataSource = emp;
        }
    }
}
