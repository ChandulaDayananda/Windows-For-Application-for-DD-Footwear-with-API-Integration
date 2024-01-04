using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using System.Xml.Linq;
using System.Reflection.Emit;
using DD_Admin.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace DD_Admin
{
    public partial class DOutlet : UserControl
    {

        public DOutlet()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            refreshdata();
        }

        private async void btnSendRequest_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];

                // Get the selected product information
                ProductOrdersDet selectedProduct = new ProductOrdersDet
                {
                    P_ID = Convert.ToInt32(row.Cells["P_ID"].Value),
                    ProductName = row.Cells["ProductName"].Value.ToString(),
                    Category = row.Cells["Category"].Value.ToString(),
                    Gender = row.Cells["Gender"].Value.ToString(),
                    Size = row.Cells["Size"].Value.ToString(),
                    Color = row.Cells["Color"].Value.ToString(),
                    Image = row.Cells["Image"].Value.ToString(),
                    IsActive = Convert.ToInt32(row.Cells["IsActive"].Value),
                    OrderDate = DateTime.Now,
                    Price = Convert.ToDecimal(row.Cells["Price"].Value),
                    R_quantity = Convert.ToInt32(txtr_quantity.Text)
                };

                // Calculate the total price
                decimal totalPrice = selectedProduct.Price * selectedProduct.R_quantity;

                // Include the total price in the success message
                string successMessage = $"Data sent successfully! Total Price: {totalPrice:C}";

                // Serialize the selected product to JSON
                string jsonData = JsonConvert.SerializeObject(selectedProduct);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44390/api/");

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("ProductOrders", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(successMessage);
                    }
                    else
                    {
                        MessageBox.Show($"Error: {response.ReasonPhrase}");
                    }
                }
            }
            else
            {
                MessageBox.Show("No row selected. Please select a row in the DataGridView.");
            }
        }


        private void get_btn_Click(object sender, EventArgs e)
        {
            HttpClient clint = new HttpClient();
            clint.BaseAddress = new Uri("https://localhost:44390/api/");
            HttpResponseMessage respose = clint.GetAsync("Footwear").Result;
            var emp = respose.Content.ReadAsAsync<IEnumerable<FootwearDet>>().Result;
            dataGridView1.DataSource = emp;
        }
        private int selectedRowIndex = -1;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                labelpname.Text = row.Cells["ProductName"].Value.ToString();
                labelptype.Text = row.Cells["Category"].Value.ToString();
                labelgender.Text = row.Cells["Gender"].Value.ToString();
                labelsize.Text = row.Cells["Size"].Value.ToString();
                labelcolor.Text = row.Cells["Color"].Value.ToString();
                labelquantity.Text = row.Cells["Quantity"].Value.ToString();
                labelprice.Text = row.Cells["Price"].Value.ToString();


                // Set the image control's ImageLocation property with the path
                string imagePath = row.Cells["image"].Value.ToString();
                if (!string.IsNullOrEmpty(imagePath))
                {
                    add_pic.ImageLocation = imagePath;
                }
            }

        }

        private void refreshdata()
        {
            try
            {
                IEnumerable<FootwearDet> empobj = null;

                using (HttpClient hc = new HttpClient())
                {
                    hc.BaseAddress = new Uri("https://localhost:44390/api/");

                    var consumeapi = hc.GetAsync("Footwear");
                    consumeapi.Wait();

                    var readdata = consumeapi.Result;
                    if (readdata.IsSuccessStatusCode)
                    {
                        var displaydata = readdata.Content.ReadAsAsync<IList<FootwearDet>>();
                        displaydata.Wait();

                        empobj = displaydata.Result;
                        dataGridView1.DataSource = empobj;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DOutlet_Load(object sender, EventArgs e)
        {

        }
    }
}
