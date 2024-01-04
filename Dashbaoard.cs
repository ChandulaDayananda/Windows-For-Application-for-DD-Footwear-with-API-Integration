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
    public partial class dashbaoard1 : UserControl
    {
        public dashbaoard1()
        {
            InitializeComponent();
        }

        private void footwearcat_btn_Click(object sender, EventArgs e)
        {
            addfootwear2.Visible = false;
            addcategories11.Visible = true;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addcategories11.Visible = false;
            addfootwear2.Visible = true;
        }
    }
}
