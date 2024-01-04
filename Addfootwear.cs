using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Formatting;
using DD_Admin.Models;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;


namespace DD_Admin
{
    public partial class Addfootwear : UserControl
    {

        public Addfootwear()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            refreshdata();

        }

        private void get_btn_Click(object sender, EventArgs e)
        {
            HttpClient clint = new HttpClient();
            clint.BaseAddress = new Uri("https://localhost:44390/api/");
            HttpResponseMessage respose = clint.GetAsync("Footwear").Result;
            var emp = respose.Content.ReadAsAsync<IEnumerable<FootwearDet>>().Result;
            dataGridView1.DataSource = emp;

        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            var selectedGender = combogender.SelectedItem as string;

            // Parse quantity to int
            if (!int.TryParse(textquatity.Text, out int parsedQuantity))
            {
                MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal parsedPrice;
            if (!decimal.TryParse(textPrice.Text, out parsedPrice))
            {
                MessageBox.Show("Please enter a valid price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a FootwearDet object with the selected values
            FootwearDet emp = new FootwearDet()
            {
                productName = textpname.Text,
                category = textptype.Text,
                gender = selectedGender,
                size = textsize.Text,
                color = textcolor.Text,
                quantity = parsedQuantity,
                price = parsedPrice,  // Set the price property with the parsed value
                image = selectedImagePath,
                isActive = 1
            };

            // Save the image to the desired path
            string targetPath = @"D:\C#\DD_Admin\DD_Admin\DD_Admin\Upload\";

            try
            {
                // Copy the file to the target path
                string targetFilePath = Path.Combine(targetPath, Path.GetFileName(selectedImagePath));
                File.Copy(selectedImagePath, targetFilePath, true);

                // Now, you can use targetFilePath as the path to store in the database or wherever needed

                emp.image = targetFilePath;  // Update the image property with the new path

                HttpClient clint = new HttpClient();
                clint.BaseAddress = new Uri("https://localhost:44390/api/");
                HttpResponseMessage response = clint.PostAsJsonAsync("Footwear", emp).Result;

                // Handle the response as needed
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Footwear added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string selectedImagePath;

        private void pic_importbtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image File (*.jpg; *.png)|*.jpg;*.png";
                string imagePath = "";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    add_pic.ImageLocation = imagePath;

                    // Store the image path
                    selectedImagePath = imagePath;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error Message"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];

                // Assuming the order of columns in the DataGridView matches the order of properties in Footwear
                int footwearId = Convert.ToInt32(row.Cells["P_ID"].Value);

                // Create a Footwear object with the updated values
                int.TryParse(textquatity.Text, out int parsedQuantity);
                decimal.TryParse(textPrice.Text, out decimal parsedPrice);
                FootwearDet updatedFootwear = new FootwearDet()
                {
                    p_ID = footwearId,
                    productName = textpname.Text,
                    category = textptype.Text,
                    gender = combogender.SelectedItem?.ToString(),
                    size = textsize.Text,
                    color = textcolor.Text,
                    quantity = parsedQuantity,
                    price = parsedPrice,
                    image = selectedImagePath,
                };

                // Call the PutFootwear method to update the data
                UpdateFootwear(footwearId, updatedFootwear);
            }
        }

        private async void UpdateFootwear(int id, FootwearDet updatedFootwear)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44390/api/");

                HttpResponseMessage response = await client.PutAsJsonAsync($"Footwear/{id}", updatedFootwear);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Footwear updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refresh the data in the DataGridView or take other actions as needed
                    refreshdata();
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private int selectedRowIndex = -1;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Assuming the order of columns in the DataGridView matches the order of properties in Footwear
                textpname.Text = row.Cells["ProductName"].Value.ToString();
                textptype.Text = row.Cells["Category"].Value.ToString();
                combogender.SelectedItem = row.Cells["Gender"].Value.ToString();
                textsize.Text = row.Cells["Size"].Value.ToString();
                textcolor.Text = row.Cells["Color"].Value.ToString();
                textquatity.Text = row.Cells["Quantity"].Value.ToString();
                textPrice.Text = row.Cells["Price"].Value.ToString();

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

        private void btndelete_Click(object sender, EventArgs e)
        {
            // Check if any rows are selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the value of the 'p_ID' column from the first selected row
                int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["p_ID"].Value);

                // Call the API to delete the selected record
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44390/api/");
                    HttpResponseMessage response = client.DeleteAsync($"Footwear/{selectedId}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        refreshdata();
                        MessageBox.Show("Footwear deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textpname.Clear();
            textptype.Clear();
            textsize.Clear();
            textcolor.Clear();
            textquatity.Clear();
            textPrice.Clear();
            combogender.SelectedIndex = -1;

            add_pic.Image = null;

            dataGridView1.ClearSelection();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            refreshdata();
        }
    }
}
