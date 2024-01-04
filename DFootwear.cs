using DD_Admin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DD_Admin
{
    public partial class dFootwear1 : UserControl
    {
        private const string ConnectionString = "server=DELL; database=DD_Footwear; Integrated Security=True; MultipleActiveResultSets=true; TrustServerCertificate=True;";

        public dFootwear1()
        {
            InitializeComponent();
            dataGridView2.CellClick += dataGridView2_CellContentClick;
            LoadData();
        }

        private void InitializeDataGridViewColumns()
        {
            // Clear existing columns if any
            dataGridView2.Columns.Clear();

            // Define DataGridView columns
            dataGridView2.Columns.Add("O_ID", "Order ID");
            dataGridView2.Columns.Add("p_ID", "Product ID");
            dataGridView2.Columns.Add("productName", "Product Name");
            dataGridView2.Columns.Add("category", "Category");
            dataGridView2.Columns.Add("gender", "Gender");
            dataGridView2.Columns.Add("size", "Size");
            dataGridView2.Columns.Add("color", "Color");
            dataGridView2.Columns.Add("availableQuantity", "Available Quantity");
            dataGridView2.Columns.Add("image", "Image");
            dataGridView2.Columns.Add("isActive", "Is Active");
            dataGridView2.Columns.Add("earliestOrderDate", "Earliest Order Date");
        }

        private void LoadData()
        {
            try
            {
                // Initialize columns if not done already
                if (dataGridView2.Columns.Count == 0)
                {
                    InitializeDataGridViewColumns();
                }

                dataGridView2.Rows.Clear(); // Clear existing rows

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = @"
                    SELECT
                    F.p_ID,
                    F.productName,
                    F.category,
                    F.gender,
                    F.size,
                    F.color,
                    F.quantity - COALESCE(SUM(P.R_quantity), 0) AS availableQuantity,
                    F.price,
                    F.image,
                    F.isActive,
                    P.O_ID,
                    MIN(P.OrderDate) AS earliestOrderDate
                FROM
                    Footwear AS F
                INNER JOIN
                    ProductOrders AS P ON F.p_ID = P.P_ID
                GROUP BY
                    F.p_ID, F.productName, F.category, F.gender, F.size, F.color, F.quantity, F.price, F.image, F.isActive, P.O_ID
                ORDER BY
                    earliestOrderDate ASC; -- Order by earliestOrderDate in ascending order


            ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    dataGridView2.Rows.Add(
                                        reader["O_ID"],
                                        reader["p_ID"],
                                        reader["productName"],
                                        reader["category"],
                                        reader["gender"],
                                        reader["size"],
                                        reader["color"],
                                        reader["availableQuantity"],
                                        reader["image"],
                                        reader["isActive"],
                                        reader["earliestOrderDate"]
                                    );
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int selectedRowIndex = -1;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                // Assuming these labels and PictureBox controls are present on your form
                labelpname.Text = row.Cells["productName"].Value.ToString();
                labelptype.Text = row.Cells["category"].Value.ToString();
                labelgender.Text = row.Cells["gender"].Value.ToString();
                labelsize.Text = row.Cells["size"].Value.ToString();
                labelcolor.Text = row.Cells["color"].Value.ToString();
                labelquantity.Text = row.Cells["availableQuantity"].Value.ToString(); 

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
                IEnumerable<ProductOrdersDet> empobj = null;

                using (HttpClient hc = new HttpClient())
                {
                    hc.BaseAddress = new Uri("https://localhost:44390/api/");

                    var consumeapi = hc.GetAsync("ProductOrders");
                    consumeapi.Wait();

                    var readdata = consumeapi.Result;
                    if (readdata.IsSuccessStatusCode)
                    {
                        var displaydata = readdata.Content.ReadAsAsync<IList<ProductOrdersDet>>();
                        displaydata.Wait();

                        empobj = displaydata.Result;
                        dataGridView2.DataSource = empobj;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateFootwearQuantity(int productId, int newQuantity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string updateQuery = @"
                UPDATE Footwear
                SET quantity = @newQuantity
                WHERE p_ID = @productId;
            ";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@newQuantity", newQuantity);
                        command.Parameters.AddWithValue("@productId", productId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Footwear quantity updated successfully");
                        }
                        else
                        {
                            Console.WriteLine("Failed to update Footwear quantity");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Footwear quantity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAcceptOrder_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[selectedRowIndex];

                int productId = Convert.ToInt32(row.Cells["p_ID"].Value);

                int availableQuantity = Convert.ToInt32(row.Cells["availableQuantity"].Value);

                if (string.IsNullOrEmpty(txtAddQuantity.Text))
                {
                    MessageBox.Show("Please enter a quantity to add.", "Missing Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit the method without further processing
                }

                // Get the quantity to add from the TextBox
                if (int.TryParse(txtAddQuantity.Text, out int quantityToAdd))
                {
                    // Calculate the new quantity
                    int newQuantity = availableQuantity + quantityToAdd;

                    // Check if the new quantity is positive
                    if (newQuantity < 0)
                    {
                        MessageBox.Show("The resulting quantity cannot be negative.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; 
                    }

                    try
                    {
                        // Update the database with the new quantity
                        UpdateFootwearQuantity(productId, newQuantity);

                        // Display the result in the label
                        labelResult.Text = $"Available Stock: {newQuantity}";

                        // Check if the O_ID is null or if the new quantity is 0 or positive
                        if (row.Cells["O_ID"].Value == DBNull.Value || newQuantity >= 0)
                        {
                            // Get the O_ID from the selected row
                            int? orderId = row.Cells["O_ID"].Value as int?;

                            // Delete the record in ProductOrders if O_ID is not null
                            if (orderId.HasValue)
                            {
                                DeleteProductOrder(orderId.Value);
                            }

                            // Remove the row from the DataGridView
                            dataGridView2.Rows.RemoveAt(selectedRowIndex);

                            // Update the quantity through the API
                            UpdateQuantityThroughApiAsync(productId, newQuantity);

                            // Display a message when the order is complete
                            MessageBox.Show("Order is complete!", "Order Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearData();
                            refreshdata();
                        }

                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating quantity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid quantity to add.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a row in the DataGridView.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task UpdateQuantityThroughApiAsync(int productId, int newQuantity)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"https://localhost:44390/api/Footwear/{productId}";

                    var requestData = new { Quantity = newQuantity };

                    string jsonContent = JsonConvert.SerializeObject(requestData);

                    StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                       
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Failed to update quantity through API. Status Code: {response.StatusCode}\nResponse Content: {responseContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating quantity through API: {ex.Message}");
            }
        }

        private void DeleteProductOrder(int orderId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Specify the API endpoint for deleting a product order
                    string apiUrl = $"https://localhost:44390/api/ProductOrders/{orderId}";

                    // Send a DELETE request to the API
                    HttpResponseMessage response = client.DeleteAsync(apiUrl).Result;

                    // Check if the request was successful (status code 200 OK)
                    if (response.IsSuccessStatusCode)
                    {
                        // Log or display a success message if needed
                        Console.WriteLine("Product order deleted successfully");
                    }
                    else
                    {
                        // Handle the case where the deletion was not successful
                        Console.WriteLine($"Error deleting product order. Status code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting ProductOrder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearData()
        {
            // Clear the DataGridView
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

            // Clear labels
            labelpname.Text = "";
            labelptype.Text = "";
            labelgender.Text = "";
            labelsize.Text = "";
            labelcolor.Text = "";
            labelquantity.Text = "";
            labelprice.Text = "";
            labelResult.Text = "";
            txtAddQuantity.Text = "";
            add_pic.Image = null;

            // Optionally, reinitialize the DataGridView columns if needed
            InitializeDataGridViewColumns();
            LoadData();
        }

        private void Get_data_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
