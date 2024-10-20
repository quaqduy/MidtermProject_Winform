using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProject_519H0157
{
    public class productHandler
    {
        private ListView productsList;
        public productHandler(ListView productsList)
        {
            this.productsList = productsList;
        }

        public void listViewProductCustom()
        {
            // Set ListView to Details mode
            productsList.View = View.Details;
            productsList.FullRowSelect = true;
            productsList.GridLines = true;

            // Add columns to ListView
            productsList.Columns.Add("ID", 50);
            productsList.Columns.Add("Name", 200);
            productsList.Columns.Add("Description", 500);
            productsList.Columns.Add("Price", 150);
            productsList.Columns.Add("Quantity", 300);
        }

        public async void LoadDataToProductListView()
        {
            // SQL query to get data from product table
            string query = "SELECT ID, Name, Description, Price, Quantity FROM Product";

            // Using the DBconnection class to manage the connection
            DBconnection db = new DBconnection(); // Initialize connection through DBconnection

            try
            {
                // Execute the query and get the SqlDataReader using DBconnection's ExecuteReader method
                using (SqlDataReader reader = db.ExecuteReader(query))
                {
                    // Clear old items in ListView
                    productsList.Items.Clear();

                    // Read data from SqlDataReader and add it to ListView
                    while (await reader.ReadAsync())
                    {
                        // Create a ListViewItem with data from the row in the SqlDataReader
                        ListViewItem item = new ListViewItem(reader["ID"].ToString());
                        item.SubItems.Add(reader["Name"].ToString());
                        item.SubItems.Add(reader["Description"].ToString());
                        item.SubItems.Add(reader["Price"].ToString());
                        item.SubItems.Add(reader["Quantity"].ToString());

                        // Add the item to ListView
                        productsList.Items.Add(item);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }
            finally
            {
                db.CloseConnection(); // Ensure the connection is closed
            }
        }
        //Double click on listviewItem
        public void productList_DoubleClick(object sender, EventArgs e)
        {
            // Check to see if any item is selected
            if (productsList.SelectedItems.Count > 0)
            {
                // Get the selected item
                ListViewItem selectedItem = productsList.SelectedItems[0];
                // Get client Name
                string productName = selectedItem.SubItems[1].Text;

                // Display MessageBox with options
                DialogResult dialogResult = MessageBox.Show(
                    "Do you want to edit information of the product: " + productName + "?",
                    "Choose an action",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // Handle results from MessageBox
                if (dialogResult == DialogResult.Yes)
                {
                    EditProduct(selectedItem);
                }
            }
        }
        private void EditProduct(ListViewItem selectedItem)
        {
            editForm editClientForm = new editForm();
            editClientForm.Show(selectedItem, "product");
        }

        public void delProductEvent()
        {
            // Check to see if any items are selected
            if (productsList.SelectedItems.Count > 0)
            {
                // Displays the confirmation dialog
                DialogResult dialogResult = MessageBox.Show("Do you really want to delete the selected products?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    List<string> clientIdsToDelete = new List<string>();

                    // Browse selected items and save each product's ID
                    foreach (ListViewItem selectedItem in productsList.SelectedItems)
                    {
                        string clientId = selectedItem.SubItems[0].Text;
                        clientIdsToDelete.Add(clientId);
                    }

                    // Delete the products from the database
                    DeleteClient(clientIdsToDelete);

                    // Remove items from ListView
                    foreach (ListViewItem selectedItem in productsList.SelectedItems)
                    {
                        productsList.Items.Remove(selectedItem);
                    }

                    MessageBox.Show("Selected products have been deleted.");
                }
            }
            else
            {
                MessageBox.Show("Please select at least one client to delete.");
            }
        }

        // Method to delete multiple products using the existing ExecuteQuery method
        private void DeleteClient(List<string> ids)
        {
            // Ensure there are IDs to delete
            if (ids == null || ids.Count == 0)
            {
                MessageBox.Show("No product IDs provided for deletion.");
                return;
            }

            // Create a delete query with parameters
            string query = "DELETE FROM Product WHERE Id IN (" + string.Join(",", ids.Select((id, index) => $"@Id{index}")) + ")";

            // Initialize DB connection
            DBconnection db = new DBconnection(); // Create a new instance of DBconnection

            // Prepare the query parameters
            for (int i = 0; i < ids.Count; i++)
            {
                query = query.Replace($"@Id{i}", $"'{ids[i]}'");
            }

            try
            {
                // Execute the delete command using ExecuteQuery
                db.ExecuteQuery(query); // Use your existing ExecuteQuery method
            }
            catch (SqlException ex)
            {
                // Handle any SQL exceptions
                Console.WriteLine("Error while deleting products: " + ex.Message);
                MessageBox.Show("Error while deleting products: " + ex.Message);
            }
        }
    }
}
