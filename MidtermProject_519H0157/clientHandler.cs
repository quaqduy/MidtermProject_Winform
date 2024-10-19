using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProject_519H0157
{
    public class clientHandler
    {
        ListView clientsList;

        public clientHandler(ListView clientsList)
        {
            this.clientsList = clientsList;
        }
        public void listViewClientCustom()
        {
            // Set ListView to Details mode
            clientsList.View = View.Details;
            clientsList.FullRowSelect = true;
            clientsList.GridLines = true;

            // Add columns to ListView
            clientsList.Columns.Add("ID", 50);
            clientsList.Columns.Add("Name", 200);
            clientsList.Columns.Add("Email", 250);
            clientsList.Columns.Add("Phone", 150);
            clientsList.Columns.Add("Address", 300);
        }

        public void LoadDataToClientListView()
        {
            // SQL query to get data from Employee table
            string query = "SELECT ID, Name, Email, Phone, Address FROM Client";

            // Using the DBconnection class to manage the connection
            DBconnection db = new DBconnection(); // Initialize connection through DBconnection

            try
            {
                // Execute the query and get the SqlDataReader using DBconnection's ExecuteReader method
                using (SqlDataReader reader = db.ExecuteReader(query))
                {
                    // Clear old items in ListView
                    clientsList.Items.Clear();

                    // Read data from SqlDataReader and add it to ListView
                    while (reader.Read())
                    {
                        // Create a ListViewItem with data from the row in the SqlDataReader
                        ListViewItem item = new ListViewItem(reader["ID"].ToString());
                        item.SubItems.Add(reader["Name"].ToString());
                        item.SubItems.Add(reader["Email"].ToString());
                        item.SubItems.Add(reader["Phone"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());

                        // Add the item to ListView
                        clientsList.Items.Add(item);
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

        public void delclientEvent()
        {
            // Check to see if any items are selected
            if (clientsList.SelectedItems.Count > 0)
            {
                // Displays the confirmation dialog
                DialogResult dialogResult = MessageBox.Show("Do you really want to delete the selected clients?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    List<string> clientIdsToDelete = new List<string>();

                    // Browse selected items and save each employee's ID
                    foreach (ListViewItem selectedItem in clientsList.SelectedItems)
                    {
                        string clientId = selectedItem.SubItems[0].Text;
                        clientIdsToDelete.Add(clientId);
                    }

                    // Delete the employees from the database
                    DeleteClient(clientIdsToDelete);

                    // Remove items from ListView
                    foreach (ListViewItem selectedItem in clientsList.SelectedItems)
                    {
                        clientsList.Items.Remove(selectedItem);
                    }

                    MessageBox.Show("Selected clients have been deleted.");
                }
            }
            else
            {
                MessageBox.Show("Please select at least one client to delete.");
            }
        }

        // Method to delete multiple employees using the existing ExecuteQuery method
        private void DeleteClient(List<string> ids)
        {
            // Ensure there are IDs to delete
            if (ids == null || ids.Count == 0)
            {
                MessageBox.Show("No client IDs provided for deletion.");
                return;
            }

            // Create a delete query with parameters
            string query = "DELETE FROM Client WHERE Id IN (" + string.Join(",", ids.Select((id, index) => $"@Id{index}")) + ")";

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
                Console.WriteLine("Error while deleting clients: " + ex.Message);
                MessageBox.Show("Error while deleting clients: " + ex.Message);
            }
        }

        //Double click on listviewItem
        public void clientList_DoubleClick(object sender, EventArgs e)
        {
            // Check to see if any item is selected
            if (clientsList.SelectedItems.Count > 0)
            {
                // Get the selected item
                ListViewItem selectedItem = clientsList.SelectedItems[0];
                // Get client Name
                string clientName = selectedItem.SubItems[1].Text;

                // Display MessageBox with options
                DialogResult dialogResult = MessageBox.Show(
                    "Do you want to edit information of the client: " + clientName + "?",
                    "Choose an action",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // Handle results from MessageBox
                if (dialogResult == DialogResult.Yes)
                {
                    EditClient(selectedItem);
                }
            }
        }

        private void EditClient(ListViewItem selectedItem)
        {
            editForm editClientForm = new editForm();
            editClientForm.Show(selectedItem, "client");
        }
    }
}
