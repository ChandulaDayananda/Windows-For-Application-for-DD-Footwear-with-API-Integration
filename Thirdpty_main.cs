using DD_Admin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DD_Admin
{
    public partial class Thirdpty_main : Form
    {
        public Thirdpty_main()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            refreshdata();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                string formattedTotalPrice = totalPrice.ToString("C", new CultureInfo("en-LK"));

                // Serialize the selected product to JSON
                string successMessage = $"Data sent successfully! Total Price: {formattedTotalPrice}";

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
                        ClearDetails();
                        refreshdata();
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 HeadForm = new Form1();
            HeadForm.Show();
            this.Hide();
        }

        private void ClearDetails()
        {
            // Clear labels
            labelpname.Text = "";
            labelptype.Text = "";
            labelgender.Text = "";
            labelsize.Text = "";
            labelcolor.Text = "";
            labelquantity.Text = "";
            labelprice.Text = "";
            txtr_quantity.Text = ""; // Assuming this is the TextBox for quantity
            add_pic.Image = null;
        }

        private void btnSendRequest_Click_1(object sender, EventArgs e)
        {

        }
    }
}
