using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
    }
}
