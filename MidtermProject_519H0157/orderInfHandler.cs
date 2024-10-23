using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProject_519H0157
{
    public class orderInfHandler
    {
        private ComboBox comboBox_employeeId;
        private ComboBox comboBox_clientId;
        private List<string> originalEmployeeData = new List<string>();
        private List<string> originalClientData = new List<string>();

        public orderInfHandler(ComboBox comboBox_employeeId, ComboBox comboBox_clientId)
        {
            this.comboBox_employeeId = comboBox_employeeId;
            this.comboBox_clientId = comboBox_clientId;
        }

        // Method to load data into ComboBox
        public void dropDataToEmployeeIDComboBox()
        {
            // SQL query to get data from Employee table
            string query = "SELECT ID, Name FROM Employee";

            // Using the DBconnection class to manage the connection
            DBconnection db = new DBconnection(); // Initialize connection through DBconnection

            try
            {
                // Execute the query and get the SqlDataReader using DBconnection's ExecuteReader method
                using (SqlDataReader reader = db.ExecuteReader(query))
                {
                    // Clear old items in ComboBox
                    this.comboBox_employeeId.Items.Clear();

                    this.comboBox_employeeId.DropDownStyle = ComboBoxStyle.DropDown;

                    // Create a list to store the original data from the database
                    List<string> employeeData = new List<string>();

                    // Read data from SqlDataReader and add it to the list
                    while (reader.Read())
                    {
                        string item = reader["ID"].ToString() + " ; " + reader["Name"].ToString();
                        employeeData.Add(item); // Store data in the original list
                        this.comboBox_employeeId.Items.Add(item); // Add to ComboBox
                    }

                    // Store the original list for use in the TextChanged event
                    this.originalEmployeeData = employeeData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Show error message
            }
        }

        // Method to load data into ComboBox
        public void dropDataToClientIDComboBox()
        {
            // SQL query to get data from Employee table
            string query = "SELECT ID, Name FROM Client";

            // Using the DBconnection class to manage the connection
            DBconnection db = new DBconnection(); // Initialize connection through DBconnection

            try
            {
                // Execute the query and get the SqlDataReader using DBconnection's ExecuteReader method
                using (SqlDataReader reader = db.ExecuteReader(query))
                {
                    // Clear old items in ComboBox
                    this.comboBox_clientId.Items.Clear();

                    this.comboBox_clientId.DropDownStyle = ComboBoxStyle.DropDown;

                    // Create a list to store the original data from the database
                    List<string> clientData = new List<string>();

                    // Read data from SqlDataReader and add it to the list
                    while (reader.Read())
                    {
                        string item = reader["ID"].ToString() + " ; " + reader["Name"].ToString();
                        clientData.Add(item); // Store data in the original list
                        this.comboBox_clientId.Items.Add(item); // Add to ComboBox
                    }

                    // Store the original list for use in the TextChanged event
                    this.originalClientData = clientData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Show error message
            }
        }

        // Method to handle the TextChanged event of the ComboBox
        public void comboBox_employeeId_TextChanged(object sender, EventArgs e)
        {
            // Get the current text that the user has entered
            string filter = comboBox_employeeId.Text;

            // If the text is empty, display all items
            if (string.IsNullOrWhiteSpace(filter))
            {
                comboBox_employeeId.Items.Clear();
                comboBox_employeeId.Items.AddRange(this.originalEmployeeData.ToArray());
            }
            else
            {
                // Filter items that contain the text entered by the user (case-insensitive)
                var filteredItems = this.originalEmployeeData
                    .Where(item => item.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToArray();

                // Update ComboBox with the filtered items
                comboBox_employeeId.Items.Clear();
                comboBox_employeeId.Items.AddRange(filteredItems);
            }

            // Set the cursor position to the end of the text to avoid jumping the cursor
            comboBox_employeeId.SelectionStart = comboBox_employeeId.Text.Length;
            comboBox_employeeId.DroppedDown = true; // Automatically open the DropDown
        }

        // Method to handle the TextChanged event of the ComboBox
        public void comboBox_clientId_TextChanged(object sender, EventArgs e)
        {
            // Get the current text that the user has entered
            string filter = comboBox_clientId.Text;

            // If the text is empty, display all items
            if (string.IsNullOrWhiteSpace(filter))
            {
                comboBox_clientId.Items.Clear();
                comboBox_clientId.Items.AddRange(this.originalClientData.ToArray());
            }
            else
            {
                // Filter items that contain the text entered by the user (case-insensitive)
                var filteredItems = this.originalClientData
                    .Where(item => item.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToArray();

                // Update ComboBox with the filtered items
                comboBox_clientId.Items.Clear();
                comboBox_clientId.Items.AddRange(filteredItems);
            }

            // Set the cursor position to the end of the text to avoid jumping the cursor
            comboBox_clientId.SelectionStart = comboBox_clientId.Text.Length;
            comboBox_clientId.DroppedDown = true; // Automatically open the DropDown
        }

        public void generalCurrentDate(Label orderDate)
        {
            orderDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        public void updateQuantityProduct(ListView productList_order, List<string> quantityForModifyDB)
        {
            try {
                // Iterate through each item in the ListView
                var count = 0;
                foreach (ListViewItem item in productList_order.Items)
                {
                    if(count < quantityForModifyDB.Count)
                    {
                        // Assuming the product ID is in the first subitem (index 0)
                        string productId = item.Text; // or item.SubItems[0].Text for the ID in a subitem
                        string quantityOrder = item.SubItems[3].Text;

                        //MessageBox.Show(quantityOrder);

                        var newQuantity = int.Parse(quantityForModifyDB[count]) - int.Parse(quantityOrder);

                        DBconnection dbconnection = new DBconnection();
                        dbconnection.OpenConnection();

                        var query = "UPDATE Product SET Quantity = " + newQuantity + " WHERE ID = " + productId;
                        dbconnection.ExecuteQuery(query);

                        dbconnection.CloseConnection();
                    }
                    count++;
                }
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.Message);
            }            

            ReloadDashBoard();
        }

        public int createOrder(string EmployeeID, string ClientID, string OrderDate, string TotalPrice)
        {
            try
            {
                DBconnection dbconnection = new DBconnection();
                dbconnection.OpenConnection();

                // Convert TotalPrice to decimal
                var TotalPriceConvert = ConvertVNDToDecimal(TotalPrice);

                // Create the query using parameters and retrieve the last inserted ID
                var query = "INSERT INTO [Order] (ClientID, EmployeeID, OrderDate, TotalPrice) " +
                            "OUTPUT INSERTED.ID " + // Output the newly inserted Order ID
                            "VALUES (@ClientID, @EmployeeID, @OrderDate, @TotalPrice)";

                int orderId = 0; // Variable to store the returned Order ID

                // Using SqlCommand to execute the query with parameters
                using (SqlCommand command = new SqlCommand(query, dbconnection.OpenConnection()))
                {
                    command.Parameters.AddWithValue("@ClientID", int.Parse(ClientID.Split(';')[0].Trim())); // Extract only ID
                    command.Parameters.AddWithValue("@EmployeeID", int.Parse(EmployeeID.Split(';')[0].Trim())); // Extract only ID
                    command.Parameters.AddWithValue("@OrderDate", DateTime.Parse(OrderDate)); // Ensure the date format is correct
                    command.Parameters.AddWithValue("@TotalPrice", TotalPriceConvert); // TotalPrice as decimal

                    // Execute the query and retrieve the Order ID
                    orderId = (int)command.ExecuteScalar(); // ExecuteScalar returns the first column of the first row, which is the Order ID
                }

                dbconnection.CloseConnection(); // Close the connection

                return orderId; // Return the newly created Order ID
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Display any errors
                return -1; // Return -1 or any other error code in case of failure
            }
        }

        public void createOrderItem(int orderId, ListView productList_order)
        {
            try
            {
                DBconnection dbconnection = new DBconnection();
                dbconnection.OpenConnection();

                // Query for inserting data into OrderItem table
                var query = "INSERT INTO OrderItem (OrderID, ProductID, Quantity) " +
                            "VALUES (@OrderID, @ProductID, @Quantity)";

                // Using SqlCommand to execute the query with parameters
                using (SqlCommand command = new SqlCommand(query, dbconnection.OpenConnection()))
                {
                    // Loop through each item in the ListView
                    foreach (ListViewItem item in productList_order.Items)
                    {
                        // Extract product ID and quantity from ListView item
                        string productID = item.SubItems[0].Text;  // ProductID is in the first column
                        string quantity = item.SubItems[3].Text;   // Quantity is in the fourth column

                        // Add parameters to the SQL command
                        command.Parameters.Clear();  // Clear previous parameters before adding new ones
                        command.Parameters.AddWithValue("@OrderID", orderId);
                        command.Parameters.AddWithValue("@ProductID", int.Parse(productID));
                        command.Parameters.AddWithValue("@Quantity", int.Parse(quantity));

                        // Execute the insert command for each product in the order
                        command.ExecuteNonQuery();
                    }
                }

                dbconnection.CloseConnection(); // Close the connection after all items are inserted
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Display any errors
            }
        }



        public decimal ConvertVNDToDecimal(string vndString)
        {
            // Remove " VND" and replace "." with "" to handle thousand separators
            string cleanedString = vndString.Replace(" VND", "").Replace(".", "").Trim();

            // Attempt to parse the cleaned string to decimal
            if (decimal.TryParse(cleanedString, out decimal totalPrice))
            {
                return totalPrice; // Successfully parsed, return the decimal value
            }
            else
            {
                throw new FormatException("Invalid VND format."); // Handle invalid format
            }
        }


        private void ReloadDashBoard()
        {
            DashBoard dashBoard = (DashBoard)Application.OpenForms["DashBoard"]; // Get instance of DashBoard
            if (dashBoard != null)
            {
                dashBoard.employeeHandler.LoadDataToEmployeeListView();
                dashBoard.clientHandler.LoadDataToClientListView();
                dashBoard.productHandler.LoadDataToProductListView();
                dashBoard.placeOrderHandler.LoadProductToListView();
            }
        }
    }
}
